using System;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Daily3Goals
{
    public partial class GoalsPage : ContentPage
    {
        GoalsViewModel viewModel;

        public GoalsPage()
        {
            InitializeComponent();

            viewModel = new GoalsViewModel(Load(), DateTime.Now);

            viewModel.GoalsChanged += (sender, goals) => {
                // Probably shouldn't save right away on every single edit
                Save(goals);
            };

            BindingContext = viewModel;
        }

        Goal[] Load()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "goals.json");
            if (File.Exists(fileName)) {
                Goal[] savedGoals = JsonConvert.DeserializeObject<Goal[]>(File.ReadAllText(fileName));
                // Only populate goal if it's the same date as today
                if (savedGoals[0].Date.Year == DateTime.Now.Year
                    && savedGoals[0].Date.Month == DateTime.Now.Month
                    && savedGoals[0].Date.Day == DateTime.Now.Day) {
                    return savedGoals;
                }
            }

            return null;
        }

        void Save(Goal[] goals)
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "goals.json");
            string json = JsonConvert.SerializeObject(goals);
            File.WriteAllText(fileName, json);
        }
    }
}
