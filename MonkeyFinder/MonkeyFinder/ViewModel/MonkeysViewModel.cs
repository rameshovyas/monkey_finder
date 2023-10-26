using MonkeyFinder.Model;
using MonkeyFinder.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MonkeyFinder.ViewModel
{
    public class MonkeysViewModel : BaseViewModel
    {
        public ObservableCollection<Monkey> Monkeys = new();
        public Command GetMonkeysCommand { get; }
        MonkeyService monkeyService;
        public MonkeysViewModel(MonkeyService monkeyService) 
        {
            Title = "Monkey Finder";
            this.monkeyService = monkeyService;
            GetMonkeysCommand = new Command(async () => await GetMonkeysAsync());
        }

        async Task GetMonkeysAsync()
        {
            if(IsBusy) 
               return;

            try
            {
                IsBusy = true;

                var monkeys = await monkeyService.GetMonkeys();
                
                if (Monkeys.Count != 0)
                    Monkeys.Clear();

                foreach (var monkey in monkeys)
                    Monkeys.Add(monkey);
            }

            catch(Exception ex) 
            {
                Debug.WriteLine($"Unable to get monkeys : {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
            }

            finally
            {
                IsBusy = false;
            }

        }

    }
}
