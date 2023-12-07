using MauiApp1.ViewModel;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
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
            PathF path = new PathF();
            path.MoveTo(40, 10);
            path.LineTo(70, 80);
            path.LineTo(10, 50);
            path.Close();
            canvas.StrokeColor = Colors.Green;
            canvas.StrokeSize = 6;
            canvas.DrawPath(path);
        }
    }
}
