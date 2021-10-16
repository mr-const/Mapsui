﻿using BruTile;
using Mapsui.Geometries;

namespace Mapsui.Extensions
{
    public static class ExtentExtensions
    {
        public static BoundingBox ToBoundingBox(this Extent extent)
        {
            return new BoundingBox(
                extent.MinX,
                extent.MinY,
                extent.MaxX,
                extent.MaxY);
        }
    }
}