using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const string INV_TYPE_EXC = "Invalid type of dough.";
        private const string WEIGHT_EXC = "Dough weight should be in the range [1..200].";
        private const double WHITE_EXTRA_CAL = 1.5;
        private const double WHOLEGRAIN = 1.0;
        private const double CRISPY = 0.9;
        private const double CHEWY = 1.1;
        private const double HOMEMADE = 1.0;
        private const double WEIGHT_MIN = 1;
        private const double WEIGHT_MAX = 200;

        private string flourType;
        private string bakingTechnique;
        private double weight;
        private double calories;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
            CaloriesCalk();
        }

        public double Calories
        {
            get
            {
                return this.calories;
            }
        }
        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (value.ToUpper()!= "WHITE" && value.ToUpper()!= "WHOLEGRAIN")
                {
                    throw new ArgumentException(INV_TYPE_EXC);
                }
                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (value.ToUpper() != "CRISPY" && value.ToUpper() != "CHEWY" && value.ToUpper() != "HOMEMADE")
                {
                    throw new ArgumentException(INV_TYPE_EXC);
                }
                this.bakingTechnique = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value<WEIGHT_MIN || value>WEIGHT_MAX)
                {
                    throw new ArgumentException(WEIGHT_EXC);
                }
                this.weight = value;
            }
        }

        private void CaloriesCalk()
        {
            double extraCal = this.weight * 2;

            switch (flourType.ToUpper())
            {
                case "WHITE":
                    extraCal *= WHITE_EXTRA_CAL;
                    break;
                case "WHOLEGRAIN":
                    extraCal *= WHOLEGRAIN;
                    break;
                default:
                    break;
            }
            switch (bakingTechnique.ToUpper())
            {
                case "CRISPY":
                    extraCal *= CRISPY;
                    break;
                case "CHEWY":
                    extraCal *= CHEWY;
                    break;
                case "HOMEMADE":
                    extraCal *= HOMEMADE;
                    break;
                default:
                    break;
            }

            this.calories = extraCal;
        }
    }
}
