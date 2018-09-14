using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Daily3Goals
{
    public partial class MainPage : ContentPage
    {
        List<Goal> goals;
        DateTime date;

        public MainPage()
        {
            goals = new List<Goal>();

            Goal goalTemplate = new Goal {
                Date = DateTime.Now,
                Name = ""
            };

            // Struct is copy by value
            goals.Add(goalTemplate);
            goals.Add(goalTemplate);
            goals.Add(goalTemplate);

            Goal1 = "Yasss";

            date = DateTime.Now;

            InitializeComponent();
        }

        public string Date => date.ToString("dddd, MMMM dd, yyyy");

        public string Goal1 {
            get => goals[0].Name;
            set {
                if (goals[0].Name != value) {
                    Goal newGoal = goals[0];
                    newGoal.Name = value;
                    goals[0] = newGoal;
                    OnPropertyChanged("Goal1");
                }
            }
        }

        public string Goal2 {
            get => goals[1].Name;
            set {
                if (goals[1].Name != value) {
                    Goal newGoal = goals[1];
                    newGoal.Name = value;
                    goals[1] = newGoal;
                    OnPropertyChanged("Goal2");
                }
            }
        }

        public string Goal3 {
            get => goals[2].Name;
            set {
                if (goals != null & goals[2].Name != value) {
                    Goal newGoal = goals[2];
                    newGoal.Name = value;
                    goals[2] = newGoal;
                    OnPropertyChanged("Goal3");
                }
            }
        }
    }
}
