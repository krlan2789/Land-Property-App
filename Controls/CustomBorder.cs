using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Land_Property_App.Controls
{
    public class CustomBorder : Border
    {
        private List<int> CornerValues = [10, 40, 70, 100];

        public CustomBorder()
        {
            AddCornerRadius();
        }

        private void AddCornerRadius()
        {
            var index = new Random().Next(4);

            StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(CornerValues[index])
            };
        }
    }
}
