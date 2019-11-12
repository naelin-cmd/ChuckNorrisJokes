using ChuckNorrisJokesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChuckNorrisJokeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatergoryPage : ContentPage
    {
        public string[] Categories { get; set; }

        public CatergoryPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var jokeGen = new JokeGenerator();

            Categories = await jokeGen.GetCategories();

            BindingContext = this;
          
        }
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
            var jokeGenerator = new JokeGenerator();
            string Laugh = await jokeGenerator.GetRandomJoke(e.Item.ToString());
            await DisplayAlert(e.Item.ToString(), Laugh,"Ok");
        }

    }
}