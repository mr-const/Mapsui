﻿using System.Diagnostics.CodeAnalysis;
using Mapsui.Layers;
using Mapsui.Nts;
using Mapsui.Samples.Common;
using Mapsui.Styles;
using Mapsui.Tiling;
using Mapsui.UI;
using Mapsui.Utilities;
using NetTopologySuite.Geometries;

namespace Mapsui.Tests.Common.Maps
{
    public class WritableLayerSample : ISample
    {
        public string Name => "WritableLayer";
        public string Category => "Special";

        public void Setup(IMapControl mapControl)
        {
            mapControl.Map = CreateMap();
        }

        [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP001:Dispose created")]
        [SuppressMessage("IDisposableAnalyzers.Correctness", "IDISP004:Don't ignore created IDisposable")]
        private Map CreateMap()
        {
            var map = new Map();

            map.Layers.Add(OpenStreetMap.CreateTileLayer());

            var writableLayer = new WritableLayer
            {
                Style = SymbolStyles.CreatePinStyle()
            };
            map.Layers.Add(writableLayer);

            map.Info += (s, e) =>
            {
                if (e.MapInfo?.WorldPosition == null) return;

                // Add a point to the layer using the Info position
                writableLayer?.Add(new GeometryFeature
                {
                    Geometry = new Point(e.MapInfo.WorldPosition.X, e.MapInfo.WorldPosition.Y)
                });
                // To notify the map that a redraw is needed.
                writableLayer?.DataHasChanged();
                return;
            };

            return map;
        }
    }
}
