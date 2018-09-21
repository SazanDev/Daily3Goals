using System;
using Xamarin.Forms;

namespace Daily3Goals
{
    public partial class GoalsPage : ContentPage
    {
        GoalsViewModel viewModel;
        GoalRepository goalRepository;

        public GoalsPage()
        {
            goalRepository = new GoalRepository();

            InitializeComponent();

            viewModel = new GoalsViewModel(goalRepository.Load(), DateTime.Now);

            viewModel.GoalsChanged += (sender, goals) => {
                // Probably shouldn't save right away on every single edit
                goalRepository.Save(goals);
            };

            BindingContext = viewModel;
        }
    }
}
