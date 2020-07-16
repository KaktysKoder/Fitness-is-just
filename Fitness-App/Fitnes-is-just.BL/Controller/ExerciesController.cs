using Fitnes_is_just.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitnes_is_just.BL.Controller
{
    public class ExerciesController : BaseController
    {
        private const string Exercies_FILE_NAME = "exercies.dat";
        private const string Activity_FILE_NAME = "activity.dat";

        private readonly User user;

        public ExerciesController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));

            Activity  = GetAllActivity();
            Exercises = GetAllExerciess();
        }

        public List<Activity> Activity { get; }  //TODO: Переписать на IEnumerable
        public List<Exercies> Exercises { get; } //TODO: Переписать на IEnumerable

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            Activity act = Activity.SingleOrDefault(a => a.Name == activity.Name);

            if (act == null)
            {
                Activity.Add(activity);

                var exercises = new Exercies(begin, end, activity, user);
                Exercises.Add(exercises);
            }
            else
            {
                var exercises = new Exercies(begin, end, act, user);
                Exercises.Add(exercises);
            }

            Save();
        }

        public void Save()
        {
            Save(Activity_FILE_NAME, Activity);
            Save(Exercies_FILE_NAME, Exercises); //Сохранили список всех упражнений.
        }

        private List<Activity> GetAllActivity() => Load<List<Activity>>(Activity_FILE_NAME) ?? new List<Activity>();

        private List<Exercies> GetAllExerciess() => Load<List<Exercies>>(Exercies_FILE_NAME) ?? new List<Exercies>();


    }
}