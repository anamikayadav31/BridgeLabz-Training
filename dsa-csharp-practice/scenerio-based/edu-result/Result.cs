using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.EduResults
{
    internal class Result
    {
        private string studentName;

        private string districtName;

        private int score;

        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }

        public string DistrictName
        {
            get { return districtName; }
            set { districtName = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

          public  override string ToString()
        {
            return $"Student Name:{studentName},District Name:{districtName},Score:{Score}";

        }
    }
}
