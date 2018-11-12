using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.AccessControl;
using TransponderReceiver;

namespace ATM
{

    public class HandleRTD
    {

        private readonly ITransponderReceiver Receiver;
        private readonly Airspace _CheckPlanes;
        private DetectSeparationEvent _detectSeparationEvent;

        public HandleRTD(ITransponderReceiver receiver, Airspace CheckPlanes)
        {
            Receiver = receiver;
            Receiver.TransponderDataReady += OnDataReady;
            _CheckPlanes = CheckPlanes;

        }

        public void OnDataReady(object sender, RawTransponderDataEventArgs e)
        {
            var datalist = e.TransponderData;
            var planeList = new List<Plane>();
            DetectSeparationEvent detectSeparationEvent = new DetectSeparationEvent();

            for(int i = 0; i<datalist.Count; i++)
            {
                var plane = Decode(datalist[i]);
                planeList.Add(plane); 
            }

            _CheckPlanes.CheckAirspace(planeList);
            detectSeparationEvent.CheckSepEvent(planeList);
        }

        public Plane Decode(string data)
        {
            var fly = new Plane();
            string[] split = data.Split(';');

            fly.Tag = split[0];
            fly.XCoordinate = Convert.ToInt32(split[1]);
            fly.YCoordinate = Convert.ToInt32(split[2]);
            fly.Altitude = Convert.ToInt32(split[3]);
            fly.TimeStamp = DateTime.ParseExact(split[4], "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
            return fly;

        }

      

    }

}