using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppKurs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {
       
        public FirstPage()
        {
            InitializeComponent();
                    
        }
       

        private void ButtonHello_Click(object sender, EventArgs e)
        {
            Label1.Text = TextArea.Text;
            Label2.Text = date.Text;

        }
        
        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (date != null)
                date.Text = " Крайний срок " + e.NewDate.ToString("dd/MM/yyyy");
        }


        async void Del_button(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
           await App.Database.DeleteItemAsync(friend.Id);
           await this.Navigation.PopAsync();
        }

        public async void ViewPlan(object sender, EventArgs e)
        {
            var page = new MainPage();
            await Navigation.PushAsync(page, true);
        }

        async void CreatePlan(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(TextArea.Text) && !string.IsNullOrWhiteSpace(date.Text))
            {
                await App.Database.SaveItemAsync(new Friend
                {
                    TextArea = TextArea.Text,
                    date = date.Text                    
                });
               
            }
           await DisplayAlert("Уведомление", "Запись добавлена", "ОK");
        }
       
    }
    
}