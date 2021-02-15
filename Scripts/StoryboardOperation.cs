using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace DDLM
{
    class StoryboardOperation
    {
        public enum EaseType
        {
            BackEase,
            BounceEase,
            CircleEase,
            CubicEase,
            ElasticEase,
            ExponentialEase,
            PowerEase,
            SineEase
        }

        public static void AddNewAnimation(
            Storyboard sb,
            double startNum,
            double endNum,
            double startTime,
            double duration,
            EaseType type,
            EasingMode em,
            DependencyObject target, 
            string path)
        {
            DoubleAnimation da = new DoubleAnimation()
            {
                From = startNum,
                To = endNum,
                BeginTime = TimeSpan.FromSeconds(startTime),
                Duration = TimeSpan.FromSeconds(duration),
                EasingFunction = (IEasingFunction)GetEase(type, em)
            };

            Storyboard.SetTarget(da, target);
            Storyboard.SetTargetProperty(da, new PropertyPath(path));
            sb.Children.Add(da);
        }

        public static object GetEase(EaseType type, EasingMode em)
        {
            switch (type)
            {
                case EaseType.BackEase:
                    return new BackEase() { EasingMode = em };

                case EaseType.BounceEase:
                    return new BounceEase() { EasingMode = em };

                case EaseType.CircleEase:
                    return new CircleEase() { EasingMode = em };

                case EaseType.CubicEase:
                    return new CubicEase() { EasingMode = em };

                case EaseType.ElasticEase:
                    return new ElasticEase() { EasingMode = em };

                case EaseType.ExponentialEase:
                    return new ExponentialEase() { EasingMode = em };

                case EaseType.PowerEase:
                    return new PowerEase() { EasingMode = em };

                case EaseType.SineEase:
                    return new SineEase() { EasingMode = em };

                default:
                    return null;
            }
        }
    }
}
