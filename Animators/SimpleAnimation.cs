namespace Land_Property_App.Animators
{
    public class SimpleAnimation
    {

        public static void FadeAndTranslate(VisualElement view, uint fadeLength = 500, uint translateLength = 750)
        {
            view.FadeTo(1, fadeLength, Easing.CubicInOut);
            view.TranslateTo(0, 0, translateLength, Easing.CubicInOut);
        }

        public static void FadeAndScale(VisualElement view, uint fadeLength = 500, uint scaleLength = 750)
        {
            view.FadeTo(1, fadeLength, Easing.CubicInOut);
            view.ScaleTo(1, scaleLength, Easing.CubicInOut);
        }

        public static void RotateView(VisualElement view) => view.RotateTo(0, 750, Easing.CubicInOut);
    }
}
