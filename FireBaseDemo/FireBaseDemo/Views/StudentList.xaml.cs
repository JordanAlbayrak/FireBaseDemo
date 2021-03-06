using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireBaseDemo.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireBaseDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentList : ContentPage
    {
        StudentRepo studentRepo = new StudentRepo();
        public StudentList()
        {
            InitializeComponent();
            //await studentRepo.GetAll();
        }
        protected override async void OnAppearing()
        {
            var students = await studentRepo.GetAll();
            StudentListView.ItemsSource = students;
        }
        private void AddToolBarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new StudentEntry());
        }

        private void EditToolBarItem_Clicked(object sender, EventArgs e)
        {

        }

        private void DeleteToolBarItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}