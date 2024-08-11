using Microsoft.Maui.Controls.Shapes;

namespace Land_Property_App.Controls
{
    public class CustomBorder : Border
    {
        private List<int> CornerValues = [10, 40, 70, 100];

        public CustomBorder()
        {
            TranslationX = new Random().Next(-500, 500);
            Rotation = Math.Max(TranslationX, 100);

            AddCornerRadius();

            Loaded += (s, e) =>
            {
                this.TranslateTo(0, 0, 1500, Easing.SinInOut);
                this.RotateTo(0, 1500, Easing.SinInOut);
            };
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
