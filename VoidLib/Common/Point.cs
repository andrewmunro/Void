using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BlackRain.Common
{
    /// <summary>
    /// A basic Point class. This provides a wrapper around the common Point type operations.
    /// </summary>
    /// 1/15/2009 12:15 AM
    [Serializable]
    //[XmlElement("Point")]
    public class Point : IComparable
    {
        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        public Point()
        {
            X = 0.0f;
            Y = 0.0f;
            Z = 0.0f;
            // BUGFIX: Apparently properties don't get set to default. Making IsValid fail.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        /// <param name="pt">The pt.</param>
        public Point(Point pt)
            : this(pt.X, pt.Y, pt.Z)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Point(float x, float y)
            : this(x, y, 0)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        public Point(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class using Xml as a source.
        /// </summary>
        /// <param name="xml"></param>
        public Point(XElement xml)
        // ReSharper disable PossibleNullReferenceException
            : this(Convert.ToSingle(xml.Attribute("X").Value),
                   Convert.ToSingle(xml.Attribute("Y").Value),
                   Convert.ToSingle(xml.Attribute("Z").Value))
        // ReSharper restore PossibleNullReferenceException
        { }


        #endregion

        /// <summary>
        /// Gets or sets the X.
        /// </summary>
        /// <value>The X.</value>
        [XmlAttribute("X")]
        public float X { get; set; }

        /// <summary>
        /// Gets or sets the Y.
        /// </summary>
        /// <value>The Y.</value>
        [XmlAttribute("Y")]
        public float Y { get; set; }

        /// <summary>
        /// Gets or sets the Z.
        /// </summary>
        /// <value>The Z.</value>
        [XmlAttribute("Z")]
        public float Z { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        [XmlIgnore]
        public bool IsValid
        {
            get { return X != 0.0 && Y != 0.0 && Z != 0.0; }
        }

        #region Distance members

        /// <summary>
        /// Gets the distance to the specified location.
        /// </summary>
        /// <param name="toX">To X.</param>
        /// <param name="toY">To Y.</param>
        /// <param name="toZ">To Z.</param>
        /// <returns></returns>
        public double Distance(float toX, float toY, float toZ)
        {
            float dX = X - toX;
            float dY = Y - toY;
            float dZ = Z - toZ;
            return Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
        }

        /// <summary>
        /// Gets the distance to the specified Point.
        /// </summary>
        /// <param name="pt">The point.</param>
        /// <returns></returns>
        public double Distance(Point pt)
        {
            return Distance(pt.X, pt.Y, pt.Z);
        }

        /// <summary>
        /// Returns the distance between two points.
        /// </summary>
        /// <param name="ptA">The pt A.</param>
        /// <param name="ptB">The pt B.</param>
        /// <returns></returns>
        public static double Distance(Point ptA, Point ptB)
        {
            return Distance(ptA.X, ptA.Y, ptA.Z, ptB.X, ptB.Y, ptB.Z);
        }



        /// <summary>
        /// Returns the distance between two points.
        /// </summary>
        /// <param name="fromX">From X.</param>
        /// <param name="fromY">From Y.</param>
        /// <param name="fromZ">From Z.</param>
        /// <param name="toX">To X.</param>
        /// <param name="toY">To Y.</param>
        /// <param name="toZ">To Z.</param>
        /// <returns></returns>
        public static double Distance(float fromX, float fromY, float fromZ, float toX, float toY, float toZ)
        {
            return
                Math.Sqrt((fromX - toX) * (fromX - toX) + (fromY - toY) * (fromY - toY) + (fromZ - toZ) * (fromZ - toZ));
        }

        /// <summary>
        /// Gets the height difference.
        /// </summary>
        /// <param name="toZ">To Z.</param>
        /// <returns></returns>
        public float HeightDiffAbs(float toZ)
        {
            return Math.Abs(Z - toZ);
        }

        /// <summary>
        /// Gets the height difference.
        /// </summary>
        /// <param name="toZ">To Z.</param>
        /// <returns></returns>
        /// 1/26/2009 4:04 PM
        public float HeightDiff(float toZ)
        {
            return toZ - Z;
        }

        /// <summary>
        /// Gets the flat distance. (Ignores Z value)
        /// </summary>
        /// <param name="toX">To X.</param>
        /// <param name="toY">To Y.</param>
        /// <returns></returns>
        public double FlatDistance(float toX, float toY)
        {
            double dX = X - toX;
            double dY = Y - toY;
            return Math.Sqrt(dX * dX + dY * dY);
        }

        #endregion

        #region <XML>

        /// <summary>
        /// Gets the XML format for the <see cref="Point">Point</see>.
        /// </summary>
        /// <returns></returns>
        public XElement GetXml()
        {
            return new XElement("Point", new XAttribute("X", X), new XAttribute("Y", Y), new XAttribute("Z", Z));
        }


        #endregion

        #region Type overloads

        /// <summary>
        /// Compares the current instance with another object of the same type.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than <paramref name="obj"/>. Zero This instance is equal to <paramref name="obj"/>. Greater than zero This instance is greater than <paramref name="obj"/>.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        /// 	<paramref name="obj"/> is not the same type as this instance. </exception>
        /// 1/15/2009 12:15 AM
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            if (obj is Point)
            {
                var p = (Point)obj;
                if (X > p.X && Y > p.Y && Z > p.Z)
                {
                    return 1;
                }
                if (X < p.X && Y < p.Y && Z < p.Z)
                {
                    return -1;
                }
                return 0;
            }
            throw new ArgumentException();
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj != null && Equals(obj as Point);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Point"/> is equal to the current <see cref="Point"/>.
        /// </summary>
        /// <param name="pt">The <see cref="Point"/> to compare with the current <see cref="Point"/>.</param>
        /// <returns>
        /// true if the specified <see cref="Point"/> is equal to the current <see cref="Point"/>; otherwise, false.
        /// </returns>
        public bool Equals(Point pt)
        {
            if (pt != null)
            {
                return Distance(pt) < .1;
            }
            return false;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return (int)((X * 60000) + (Y));
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", X, Y, Z);
        }

        #endregion

        #region Operator Overloads

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <returns>The result of the operator.</returns>
        /// 1/15/2009 12:14 AM
        public static bool operator <(Point p1, Point p2)
        {
            return (p1.CompareTo(p2) < 0);
        }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <returns>The result of the operator.</returns>
        /// 1/15/2009 12:15 AM
        public static bool operator >(Point p1, Point p2)
        {
            return (p1.CompareTo(p2) > 0);
        }

        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <returns>The result of the operator.</returns>
        /// 1/15/2009 12:15 AM
        public static bool operator <=(Point p1, Point p2)
        {
            return (p1.CompareTo(p2) <= 0);
        }

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <returns>The result of the operator.</returns>
        /// 1/15/2009 12:15 AM
        public static bool operator >=(Point p1, Point p2)
        {
            return (p1.CompareTo(p2) >= 0);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        /// 1/15/2009 12:15 AM
        public static double operator *(Point a, Point b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        /// 1/15/2009 12:15 AM
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        /// 1/15/2009 12:15 AM
        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="d">The d.</param>
        /// <returns>The result of the operator.</returns>
        /// 1/15/2009 12:15 AM
        public static Point operator *(Point a, float d)
        {
            return new Point(a.X * d, a.Y * d, a.Z * d);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="ptA">The pt A.</param>
        /// <param name="ptB">The pt B.</param>
        /// <returns>The result of the operator.</returns>
        /// 1/15/2009 12:15 AM
        public static bool operator ==(Point ptA, Point ptB)
        {
            return ptA.Equals(ptB);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="ptA">The pt A.</param>
        /// <param name="ptB">The pt B.</param>
        /// <returns>The result of the operator.</returns>
        /// 1/15/2009 12:15 AM
        public static bool operator !=(Point ptA, Point ptB)
        {
            return !ptA.Equals(ptB);
        }

        #endregion
    }

}
