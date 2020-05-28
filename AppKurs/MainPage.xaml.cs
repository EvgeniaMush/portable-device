using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using SQLite;

namespace AppKurs
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
           
        }

       
    

        protected override async void OnAppearing()
        {
            // создание таблицы, если ее нет
            await App.Database.CreateTable();
            // привязка данных
            friendsList.ItemsSource = await App.Database.GetItemsAsync();

            base.OnAppearing();
        }

       
        public async void Enter_Button(object sender, EventArgs e)
        {
            var page = new FirstPage();
            page.BackgroundColor = Color.Moccasin;
            await Navigation.PushAsync(page, true);

        }
       
        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Friend selectedFriend = (Friend)e.SelectedItem;
            FirstPage friendPage = new FirstPage();
            friendPage.BindingContext = selectedFriend;
            await Navigation.PushAsync(friendPage);
        }
    }
}
