using System;

namespace AndroidWTInsider.DataArrays
{
    public static class BRArray
    {
        /// <summary>
        /// Tanks battle rating
        /// </summary>
        /// <returns>Array of BR</returns>
        public static double[] TanksBR() => new double[] { 1.0, 1.3, 1.7, 2.0, 2.3, 2.7, 3.0, 3.3, 3.7, 4.0, 4.3, 4.7, 5.0, 5.3, 5.7, 6.0, 6.3, 6.7, 7.0, 7.3, 7.7, 8.0, 8.3, 8.7, 9.0, 9.3, 9.7, 10.0, 10.3, 10.7 };

        /// <summary>
        /// Planes battle rating
        /// </summary>
        /// <returns>Array of BR</returns>
        public static double[] PlanesBR() => new double[] { 1.0, 1.3, 1.7, 2.0, 2.3, 2.7, 3.0, 3.3, 3.7, 4.0, 4.3, 4.7, 5.0, 5.3, 5.7, 6.0, 6.3, 6.7, 7.0, 7.3, 7.7, 8.0, 8.3, 8.7, 9.0, 9.3, 9.7, 10.0, 10.3 };

        /// <summary>
        /// Helis battle rating
        /// </summary>
        /// <returns>Array of BR</returns>
        public static double[] HelisBR() => new double[] { 8.0, 8.3, 8.7, 9.0, 9.3, 9.7, 10.0, 10.3, 10.7 };

        /// <summary>
        /// Ship battle rating
        /// </summary>
        /// <returns>Array of BR</returns>
        public static double[] ShipsBR() => new double[] { 1.0, 1.3, 1.7, 2.0, 2.3, 2.7, 3.0, 3.3, 3.7, 4.0, 4.3, 4.7, 5.0, 5.3, 5.7, 6.0 };
    }
}