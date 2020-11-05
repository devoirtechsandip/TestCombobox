using MvvmHelpers.Commands;
using Syncfusion.XForms.ComboBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class TestComboViewModel : ViewModelBase
    {

        private ObservableCollection<UserMaster> _DriverList;
        public ObservableCollection<UserMaster> DriverList
        {
            get { return _DriverList; }
            set { SetProperty(ref _DriverList, value); }
        }
        public AsyncCommand AddRoutePatrolCommand { get; set; }

        public TestComboViewModel()
        {
            AddRoutePatrolCommand = new AsyncCommand(AddRoutePatrolCommandFunc);

            DriverList = new ObservableCollection<UserMaster>();
            DriverList.Add(new UserMaster { Id = "1", Name = "Test1" });
            DriverList.Add(new UserMaster { Id = "2", Name = "Test2" });
            DriverList.Add(new UserMaster { Id = "3", Name = "Test3" });
            DriverList.Add(new UserMaster { Id = "4", Name = "Test4" });
        }

        private async Task AddRoutePatrolCommandFunc()
        {
            var result = MultiDriverList;
            //var result2 = SelectedvalueCollection;
        }

        //Test multiselection

        //private List<string> selectedId = new List<string>();
        //public List<string> SelectedId
        //{

        //    get { return selectedId; }
        //    set { SetProperty(ref selectedId, value); }
        //    //get
        //    //{
        //    //    return selectedId;
        //    //}
        //    //set
        //    //{
        //    //    selectedId = value;
        //    //    RaisePropertyChanged("SelectedId");
        //    //}
        //}

        private ObservableCollection<object> selectedvalueCollection = new ObservableCollection<object>();

        public ObservableCollection<object> SelectedvalueCollection
        {
            get { return selectedvalueCollection; }
            set { SetProperty(ref selectedvalueCollection, value); }

            //get { return selectedvalueCollection; }
            //set
            //{
            //    selectedvalueCollection = value;
            //    RaisePropertyChanged("SelctedvalueCollection");

            //}
        }

        private ObservableCollection<object> multiSelectedItem;

        public ObservableCollection<object> MultiSelectedItem
        {

            get { return multiSelectedItem; }
            set
            {
                SetProperty(ref multiSelectedItem, value, "Onchange", OnchangeMultiSelectedItem);
            }


        }

        private ObservableCollection<object> tempselectedvalueCollection = new ObservableCollection<object>();

        public void OnchangeMultiSelectedItem()
        {
            tempselectedvalueCollection.Clear();
            foreach (var item in multiSelectedItem)
            {
                tempselectedvalueCollection.Add((item as UserMaster).Id);
            }
            SelectedvalueCollection = tempselectedvalueCollection;
        }


        private ObservableCollection<object> _ComboSelectionChanged;
        public ObservableCollection<object> ComboSelectionChanged
        {


            get { return _ComboSelectionChanged; }
            set
            {
                SetProperty(ref _ComboSelectionChanged, value, "Onchange", OnchangeComboSelectionChanged);
            }


        }

        

        public void OnchangeComboSelectionChanged()
        {
            tempselectedvalueCollection.Clear();
            foreach (var item in multiSelectedItem)
            {
                tempselectedvalueCollection.Add((item as UserMaster).Id);
            }
            SelectedvalueCollection = tempselectedvalueCollection;
        }

        private ObservableCollection<UserMaster> _MultiDriverList;
        public ObservableCollection<UserMaster> MultiDriverList
        {
            get { return _MultiDriverList; }
            set { SetProperty(ref _MultiDriverList, value); }

            //set
            //{
            //    _MultiDriverList = value;
            //    RaisePropertyChanged("SelectedItems");

            //    tempselectedvalueCollection.Clear();
            //    foreach (var item in _MultiDriverList)
            //    {
            //        tempselectedvalueCollection.Add((item as UserMaster).Id);
            //    }
            //    SelectedvalueCollection = tempselectedvalueCollection;
            //}
        }
    }

    public class UserMaster
    {
        public string Id { get; set; }
        public string Name { get; set; }
       
    }

    public class SelectionChangedBehavior : Behavior<SfComboBox>
    {
        TestComboViewModel employeeViewModel;
        protected override void OnAttachedTo(SfComboBox bindable)
        {
            bindable.SelectionChanged += Bindable_SelectionChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(SfComboBox bindable)
        {
            bindable.SelectionChanged -= Bindable_SelectionChanged;
            base.OnDetachingFrom(bindable);
        }

        void Bindable_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            employeeViewModel = new TestComboViewModel();
            var selectedValue = e.Value as List<object>;

            //employeeViewModel.MultiDriverList.Clear();


            foreach (var item in selectedValue)
            {

                employeeViewModel.MultiDriverList.Add(item as UserMaster);
            }
        }
    }
}
