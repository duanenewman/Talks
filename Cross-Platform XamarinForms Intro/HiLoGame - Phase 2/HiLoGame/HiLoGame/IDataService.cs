﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiLoGame
{
	public interface IDataService
	{
		string GetScoreData();
		void SetScoreData(string data);
	}
}
