using Microsoft.Maui.Controls;

namespace PA
{
    public partial class MainPage : ContentPage
    {
        private readonly DBService _dbService;
        private int _editTermID;

        public MainPage(DBService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => termsView.ItemsSource = await _dbService.GetTerms());
        }
        private async void addTermButton_Clicked(object sender, EventArgs e)
        {
            if (_editTermID == 0)
            {
                // add term
                await _dbService.Create(new Term
                {
                    TermName = TermNameField.Text,
                    StartDate = TermStartPicker.Date,
                    EndDate = TermEndPicker.Date,
                });
            }
            else 
            {
                // Edit term
                await _dbService.Update(new Term
                {
                    ID = _editTermID,
                    TermName = TermNameField.Text,
                    StartDate = TermStartPicker.Date,
                    EndDate = TermEndPicker.Date,
                    
                });

                _editTermID = 0;
            }

            TermNameField.Text = string.Empty;
            TermStartPicker.Date = DateTime.Now;
            TermEndPicker.Date = DateTime.Now;

            termsView.ItemsSource = await _dbService.GetTerms();
        }
        private async void termsView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var term = (Term)e.Item;
            var doSomething = await DisplayActionSheet("What Would You Like To Do?", "Cancel", null, "Change Term Info", "Delete Term", "View Term");

            switch (doSomething)
            {
                case "Change Term Info":
                    
                    _editTermID = term.ID;
                    TermNameField.Text = term.TermName;
                    TermStartPicker.Date = term.StartDate;
                    TermEndPicker.Date = term.EndDate;

                    break;
                case "Delete Term":

                    await _dbService.Delete(term);
                    termsView.ItemsSource = await _dbService.GetTerms();
                    //TODO: This must also cascade to any courses within the term

                    break;
                case "View Term":
                    await Navigation.PushModalAsync(new CoursePage(term.ID, _dbService));
                    break;
            }
        }

    }

}
