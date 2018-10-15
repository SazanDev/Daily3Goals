using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Daily3Goals
{
    public partial class GoalsPage : ContentPage
    {
        GoalsViewModel viewModel;
        GoalRepository goalRepository;
        DateTime currentDate;

        public GoalsPage()
        {
            goalRepository = new GoalRepository();
            currentDate = DateTime.Now;

            InitializeComponent();

            InitializeViewModel();
        }

        async Task InitializeViewModel()
        {
            viewModel = new GoalsViewModel(await goalRepository.Load(currentDate), currentDate);

            viewModel.GoalsChanged += (sender, goals) => {
                // Probably shouldn't save right away on every single edit
                goalRepository.Save(goals);
            };

            viewModel.PreviousDayRequested += async (sender, e) => {
                currentDate = currentDate.AddDays(-1);
                viewModel.UpdateDate(await goalRepository.Load(currentDate), currentDate);
            };

            viewModel.NextDayRequested += async (sender, e) => {
                currentDate = currentDate.AddDays(1);
                viewModel.UpdateDate(await goalRepository.Load(currentDate), currentDate);
            };

            BindingContext = viewModel;
        }
    }
}
