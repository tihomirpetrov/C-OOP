namespace P06.TrafficLights
{
    using System;

    public class TrafficLight
    {
        private Signal currentSignal;

        public TrafficLight(string signal)
        {
            this.currentSignal = (Signal)Enum.Parse(typeof(Signal), signal);
        }

        public void UpdateSignal()
        {
            int previousState = (int)currentSignal;

            currentSignal = (Signal)(++previousState % Enum.GetNames(typeof(Signal)).Length);
        }
    }
}