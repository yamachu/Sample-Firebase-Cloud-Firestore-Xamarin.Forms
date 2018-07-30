using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirestoreRe.Models.DataObjects;
using FirestoreRe.Repositories;
using Xamarin.Forms;

namespace FirestoreRe
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            DocumentGetButton.Clicked += async (sender, e) =>
            {
                var collections = await DependencyService.Get<IRepository<Event>>().GetAllAsync();
                this.BindingContext = collections;
            };
        }
    }
}
