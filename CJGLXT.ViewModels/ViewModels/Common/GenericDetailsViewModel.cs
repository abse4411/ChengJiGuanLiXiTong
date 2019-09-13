using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CJGLXT.ViewModels.Services;

namespace CJGLXT.ViewModels.ViewModels.Common
{
    public abstract partial class GenericDetailsViewModel<TModel>: ObservableObject where TModel : ObservableObject, new()
    {
        public IDialogService DialogService { get; }
        public bool IsDataAvailable => _item != null;
        public bool IsDataUnavailable => !IsDataAvailable;

        protected GenericDetailsViewModel(IDialogService dialogService)
        {
            DialogService = dialogService;
        }

        public virtual string Title { get; }

        private TModel _item = null;
        public TModel Item
        {
            get => _item;
            set
            {
                if (Set(ref _item, value))
                {
                    EditableItem = _item;
                    IsEnabled = (!_item?.IsEmpty) ?? false;
                    NotifyChanges();
                }
            }
        }

        private TModel _editableItem = null;
        public TModel EditableItem
        {
            get => _editableItem;
            set => Set(ref _editableItem, value);
        }

        private bool _isEditMode = false;
        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                IsReadOnly = !value;
                Set(ref _isEditMode, value);
            }
        }

        private bool _isReadOnly = true;
        public bool IsReadOnly
        {
            get => _isReadOnly;
            set => Set(ref _isReadOnly, value);
        }

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => Set(ref _isEnabled, value);
        }

        public ICommand BackCommand => new RelayCommand(OnBack);
        protected virtual void OnBack()
        {
            //if (NavigationService.CanGoBack)
            //{
            //    NavigationService.GoBack();
            //}
        }

        public ICommand EditCommand => new RelayCommand(OnEdit);
        protected virtual void OnEdit()
        {
            BeginEdit();
        }
        public virtual void BeginEdit()
        {
            if (!IsEditMode)
            {
                IsEditMode = true;
                var editableItem = new TModel();
                editableItem.Merge(Item);
                EditableItem = editableItem;
            }
        }

        public ICommand CancelCommand => new RelayCommand(OnCancel);
        protected virtual void OnCancel()
        {
            CancelEdit();
        }
        public virtual void CancelEdit()
        {
            if (ItemIsNew)
            {
                //if (NavigationService.CanGoBack)
                //{
                //    NavigationService.GoBack();
                //}
                //else
                //{
                //    NavigationService.CloseViewAsync();
                //}
                return;
            }

            if (IsEditMode)
            {
                EditableItem = Item;
            }
            IsEditMode = false;
        }

        public ICommand SaveCommand => new RelayCommand(OnSave);
        protected virtual async void OnSave()
        {
            var result = Validate(EditableItem);
            if (result.IsOk)
            {
                await SaveAsync();
            }
            else
            {
                 await DialogService.ShowAsync(result.Message, $"{result.Description} 请更正错误后重试！");
            }
        }
        public virtual async Task SaveAsync()
        {
            IsEnabled = false;
            bool isNew = ItemIsNew;
            if (await SaveItemAsync(EditableItem))
            {
                Item.Merge(EditableItem);
                Item.NotifyChanges();
                NotifyPropertyChanged(nameof(Title));
                EditableItem = Item;

                if (isNew)
                {
                    //MessageService.Send(this, "NewItemSaved", Item);
                }
                else
                {
                    //MessageService.Send(this, "ItemChanged", Item);
                }
                IsEditMode = false;

                NotifyPropertyChanged(nameof(ItemIsNew));
            }
            IsEnabled = true;
        }

        public ICommand DeleteCommand => new RelayCommand(OnDelete);
        protected virtual async void OnDelete()
        {
            if (await ConfirmDeleteAsync())
            {
                await DeleteAsync();
            }
        }
        public virtual async Task DeleteAsync()
        {
            var model = Item;
            if (model != null)
            {
                IsEnabled = false;
                if (await DeleteItemAsync(model))
                {
                    await DialogService.ShowAsync("删除成功", string.Empty);
                    IsEditMode = true;
                    Item = new TModel();
                }
                else
                {
                    await DialogService.ShowAsync("删除失败", string.Empty);
                    IsEnabled = true;
                }
            }
        }

        virtual public Result Validate(TModel model)
        {
            foreach (var constraint in GetValidationConstraints(model))
            {
                if (!constraint.Validate(model))
                {
                    return Result.Error("验证未通过", constraint.Message);
                }
            }
            return Result.Ok();
        }

        protected virtual IEnumerable<IValidationConstraint<TModel>> GetValidationConstraints(TModel model) => Enumerable.Empty<IValidationConstraint<TModel>>();

        public abstract bool ItemIsNew { get; }

        protected abstract Task<bool> SaveItemAsync(TModel model);
        protected abstract Task<bool> DeleteItemAsync(TModel model);
        protected abstract Task<bool> ConfirmDeleteAsync();
    }
}
