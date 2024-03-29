﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using CJGLXT.ViewModels.Services;

namespace CJGLXT.ViewModels.ViewModels.Common
{
    public abstract partial class GenericListViewModel<TModel> : ObservableObject where TModel : ObservableObject
    {
        public IDialogService DialogService { get; }

        public GenericListViewModel(IDialogService dialogService)
        {
            DialogService = dialogService;
        }


        public virtual string Title { get; }

        private IList<TModel> _items = null;
        public IList<TModel> Items
        {
            get => _items;
            set => Set(ref _items, value);
        }

        private int _itemsCount = 0;
        public int ItemsCount
        {
            get => _itemsCount;
            set => Set(ref _itemsCount, value);
        }

        private TModel _selectedItem = default(TModel);
        public TModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (Set(ref _selectedItem, value))
                {
                    //if (!IsMultipleSelection)
                    //{
                    //    MessageService.Send(this, "ItemSelected", _selectedItem);
                    //}
                }
            }
        }

        private bool _isMultipleSelection = false;
        public bool IsMultipleSelection
        {
            get => _isMultipleSelection;
            set => Set(ref _isMultipleSelection, value);
        }

        public List<TModel> SelectedItems { get; protected set; }
        public IndexRange[] SelectedIndexRanges { get; protected set; }

        public ICommand NewCommand => new RelayCommand(OnNew);

        public ICommand RefreshCommand => new RelayCommand(OnRefresh);

        public ICommand StartSelectionCommand => new RelayCommand(OnStartSelection);
        virtual protected void OnStartSelection()
        {
            SelectedItem = null;
            SelectedItems = new List<TModel>();
            SelectedIndexRanges = null;
            IsMultipleSelection = true;
        }

        public ICommand CancelSelectionCommand => new RelayCommand(OnCancelSelection);
        virtual protected void OnCancelSelection()
        {
            SelectedItems = null;
            SelectedIndexRanges = null;
            IsMultipleSelection = false;
            SelectedItem = Items?.FirstOrDefault();
        }

        public ICommand SelectItemsCommand => new RelayCommand<IList<object>>(OnSelectItems);
        virtual protected void OnSelectItems(IList<object> items)
        {
            if (IsMultipleSelection)
            {
                SelectedItems.AddRange(items.Cast<TModel>());
            }
        }

        public ICommand DeselectItemsCommand => new RelayCommand<IList<object>>(OnDeselectItems);
        protected virtual void OnDeselectItems(IList<object> items)
        {
            if (items?.Count > 0)
            {

            }
            if (IsMultipleSelection)
            {
                foreach (TModel item in items)
                {
                    SelectedItems.Remove(item);
                }

            }
        }

        public ICommand SelectRangesCommand => new RelayCommand<IndexRange[]>(OnSelectRanges);
        protected virtual void OnSelectRanges(IndexRange[] indexRanges)
        {
            SelectedIndexRanges = indexRanges;
            int count = SelectedIndexRanges?.Sum(r => r.Length) ?? 0;
        }

        public ICommand DeleteSelectionCommand => new RelayCommand(OnDeleteSelection);

        protected abstract void OnNew();
        protected abstract void OnRefresh();
        protected abstract void OnDeleteSelection();

    }

    public class IndexRange
    {
        public int Index { get; set; }
        public int Length { get; set; }
    }
}
