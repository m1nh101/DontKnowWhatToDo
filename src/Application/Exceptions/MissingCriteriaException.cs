using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions;

public class MissingCriteriaException : Exception
{
	public MissingCriteriaException(): base("cannot query due to missing criteria")
	{
	}
}