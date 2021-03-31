using System;

namespace c968
{
	public struct BasePart
    {
		public int intPartID;
		public string strName;
		public float fltPrice;
		public int intInStock;
		public int intMin;
		public int intMax;
	}

	public abstract class Part
	{
		protected int aPartID;
		protected string aName;
		protected float aPrice;
		protected int aInStock;
		protected int aMin;
		protected int aMax; 

		public int getPartID()
        {
			return aPartID;
        }

		public string getName()
        {
			return aName;
        }
		public float getPrice()
        {
			return aPrice;
        }

		public int getInStock()
        {
			return aInStock;
        }

		public int getMin()
        {
			return aMin;
        }

		public int getMax()
        {
			return aMax;
        }

		public void setPartID(int partID)
        {
			aPartID = partID;
        }

		public void setName(string name)
        {
			aName = name;
        }

		public void setPrice(float price)
        {
			aPrice = price;
        }

		public void setInStock(int inStock)
        {
			aInStock = inStock;
        }

		public void setMin(int min)
        {
			aMin = min;
        }

		public void setMax(int max)
        {
			aMax = max;
        }
	}
}
