﻿using System;

namespace Mapsui.Widgets;

/// <summary>
/// Widget that gets touch events
/// </summary>
public abstract class TouchableWidget : Widget, ITouchableWidget
{
    /// <summary>
    /// Type of area to use for touch events
    /// </summary>
    private TouchableAreaType _touchableArea = TouchableAreaType.Widget;

    /// <summary>
    /// Type of area to use for touch events
    /// </summary>
    public TouchableAreaType TouchableArea
    {
        get => _touchableArea;
        set
        {
            if (_touchableArea == value)
                return;
            _touchableArea = value;
            Invalidate();
        }
    }

    /// <summary>
    /// Function, which handles the widget touched event
    /// </summary>
    /// <param name="navigator">Navigator of MapControl</param>
    /// <param name="position">Screen position</param>
    /// <param name="args">Arguments for this widget touch</param>
    /// <returns>True, if the Widget had handled the touch event</returns>
    public virtual bool HandleWidgetTouched(Navigator navigator, MPoint position, WidgetTouchedEventArgs args)
    {
        return args.Handled;
    }

    /// <summary>
    /// Function, which handles the widget touching event
    /// </summary>
    /// <param name="navigator">Navigator of MapControl</param>
    /// <param name="position">Screen position</param>
    /// <param name="args">Arguments for this widget touch</param>
    /// <returns>True, if the Widget had handled the touch event</returns>
    public virtual bool HandleWidgetTouching(Navigator navigator, MPoint position, WidgetTouchedEventArgs args)
    {
        return args.Handled;
    }

    /// <summary>
    /// Function, which handles the widget moving event
    /// </summary>
    /// <param name="navigator">Navigator of MapControl</param>
    /// <param name="position">Screen position</param>
    /// <param name="args">Arguments for this widget touch</param>
    /// <returns>True, if the Widget had handled the touch event</returns>
    public virtual bool HandleWidgetMoving(Navigator navigator, MPoint position, WidgetTouchedEventArgs args)
    {
        return args.Handled;
    }

}
