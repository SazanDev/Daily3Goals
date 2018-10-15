using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Daily3Goals
{
    public class GoalRepository
    {
        // We'll be using the date string as the key for the dictionary
        const string DateFormat = "yyyy-MM-dd";

        // Stores goals in memory
        Dictionary<string, List<Goal>> goals;

        public async Task Save(Goal[] newGoals)
        {
            if (newGoals != null && newGoals.Length > 0) {
                // Not the best idea, but we're using the fact that goals will be null if goals have not been loaded from 
                // file yet
                if (goals == null) {
                    goals = new Dictionary<string, List<Goal>>();
                    await PopulateGoals();
                }

                var key = newGoals[0].Date.ToString(DateFormat);
                if (!goals.ContainsKey(key)) {
                    goals.Add(key, new List<Goal>());
                }

                goals[key].Clear();
                goals[key].AddRange(newGoals);

                await SaveToFile();
            }
        }

        public async Task<Goal[]> Load(DateTime date)
        {
            // Not the best idea, but we're using the fact that goals will be null if goals have not been loaded from 
            // file yet
            if (goals == null) {
                goals = new Dictionary<string, List<Goal>>();
                await PopulateGoals();
            }

            var key = date.ToString(DateFormat);
            if (goals.ContainsKey(key)) {
                return goals[key].ToArray();
            } else {
                return null;
            }
        }

        Task PopulateGoals()
        {
            return Task.Run(() => {
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "goals.json");
                if (File.Exists(fileName)) {
                    Goal[] savedGoals = JsonConvert.DeserializeObject<Goal[]>(File.ReadAllText(fileName));
                    if (savedGoals != null) {
                        foreach (var goal in savedGoals) {
                            var key = goal.Date.ToString(DateFormat);
                            if (!goals.ContainsKey(key)) {
                                goals.Add(key, new List<Goal>());
                            }

                            goals[key].Add(goal);
                        }
                    }
                }
            });
        }

        Task SaveToFile()
        {
            return Task.Run(() => {
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "goals.json");
                // Save all goals to file. There's a better way that will be introduced later.
                List<Goal> goalList = new List<Goal>();
                foreach (var goalPair in goals) {
                    goalList.AddRange(goalPair.Value);
                }
                string json = JsonConvert.SerializeObject(goalList);
                File.WriteAllText(fileName, json);
            });
        }
    }
}
