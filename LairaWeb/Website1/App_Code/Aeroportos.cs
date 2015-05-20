using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Aeroportos
/// </summary>
/// 

public class Aeroportos
{
 
   public string CODIGO {get; set;}
    public string NOME {get; set;}

	public Aeroportos()
	{
		//
		// TODO: Add constructor logic here
		//
	}

      public List<Aeroportos> GetAeroportos()
    {
           List<Aeroportos> xList = new List<Aeroportos>();
            Aeroportos account = new Aeroportos();
            account.CODIGO = "SBGL";
            account.NOME = "GALEAO";
                       
          xList.Add(account);

          return xList;
     }
}