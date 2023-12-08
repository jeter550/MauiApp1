using MauiApp1.ViewModel;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.CustomComponents
{
    public class GraphicsComponent : GraphicsView, IDrawable
    {

        public GraphicsComponent()
        {
            this.Drawable = this;
        }

        public static readonly BindableProperty ItemsSourceProperty =  BindableProperty.Create("ItemsSource", typeof(List<GraphicItem>), typeof(GraphicsComponent), new List<GraphicItem>(0), 
            propertyChanged: 
            (BindableObject bindable, object oldValue, object newValue) => 
            {
                bindable.SetValue(ItemsSourceProperty, newValue);
                ((GraphicsComponent)bindable).Invalidate();
            });

        public List<GraphicItem> ItemsSource
        {
            get => 
                (List<GraphicItem>)GetValue(ItemsSourceProperty);
            set
            { 
                SetValue(ItemsSourceProperty, value);
            }
        }

        public static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
                if (oldValue != newValue)
                {
                    bindable.SetValue(GraphicsComponent.ItemsSourceProperty, newValue);
                }
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {            
            if (this.ItemsSource is null || this.ItemsSource.Count == 0)
                return;

            GraphicBuild(canvas, dirtyRect);
        }

        private void GraphicBuild(ICanvas canvas, RectF dirtyRect)
        {
            double maxvalue = this.ItemsSource.Where(s => !double.IsInfinity(s.Valor)).Max(s => s.Valor);            

            double with = this.Width;
            double height = this.Height;

            PointF point1 = new PointF(0, Convert.ToInt64(height));
            PointF point2 = new PointF(0, Convert.ToInt64(height));

            float distance = Convert.ToInt64(Width / ItemsSource.Count);

            Random rd = new Random();

            this.ItemsSource.ForEach(s => 
            {
                if (double.IsInfinity(s.Valor)) return;

                double perc = s.Valor / maxvalue;

                float part = Convert.ToInt64(height - (height * perc) );

                point1.X = point2.X;
                point1.Y = point2.Y;
                point2.X += distance;
                point2.Y = part; 

                canvas.StrokeColor = Colors.BlueViolet;
                canvas.StrokeSize = 1;
                canvas.DrawLine(point1, point2);

            });
        }
    }
}
