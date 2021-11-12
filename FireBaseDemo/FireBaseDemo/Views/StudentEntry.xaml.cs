using FireBaseDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FireBaseDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentEntry : ContentPage
    {
        StudentRepo repository = new StudentRepo();
        public StudentEntry()
        {
            InitializeComponent();
        }
        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            string Lname = txtLName.Text;
            string Fname = txtFName.Text;
            string Email = txtEmail.Text;
            if (String.IsNullOrEmpty(Lname))
            {
                await DisplayAlert("Required", "Enter last name", "Cancel");
            }
            if (String.IsNullOrEmpty(Fname))
            {
                await DisplayAlert("Required", "Enter first name", "Cancel");
            }
            if (String.IsNullOrEmpty(Email))
            {
                await DisplayAlert("Required", "Enter email", "Cancel");
            }
            Student student = new Student();
            student.LastName = Lname;
            student.FirstName = Fname;
            student.Email = Email;
            var isSaved = await repository.Save(student);
            if (isSaved)
            {
                await DisplayAlert("Success", "Saved", "Cancel");
            }
            else
            {
                await DisplayAlert("Failed", "Did not save", "Cancel");
            }
            ClearStudent();
        }
        private void ClearStudent()
        {
            txtLName.Text = String.Empty;
            txtFName.Text = String.Empty;
            txtEmail.Text = String.Empty;
        }
    }
}