using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bryan.BMI.Practice.BO
{
    public class BMI
    {
        public float Height { get; set; }

        public float Weight { get; set; }

        public float Result
        {
            get
            {
                return Calucate();
            }
            
        }

        private float Calucate()
        {
            float result = 0;
            //待會讓他有錯
            float height = (float)Height / 100;
            result = Weight / (height * height);

            return result;
        }
    }
}
