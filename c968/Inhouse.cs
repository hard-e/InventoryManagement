using System;

namespace c968
{
	public class Inhouse : Part
	{
		private int intMachineID;

		public int getMachineID()
		{
			return intMachineID;
		}

		public void setMachineID(int machineID)
        {
			intMachineID = machineID;
        }

		public Inhouse(BasePart p, int machineID)
		{
			setPartID(p.intPartID);
			setName(p.strName);
			setPrice(p.fltPrice);
			setInStock(p.intInStock);
			setMin(p.intMin);
			setMax(p.intMax);
			setMachineID(machineID);
		}
	}
}
