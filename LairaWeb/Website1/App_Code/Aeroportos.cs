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

    #region Propriedades
    public string CODIGO {get; set;}
    public string NOME {get; set;}
    #endregion

    public Aeroportos()
	{
		//
		// TODO: Add constructor logic here
		//
	}
/// <summary>
/// Retornar Lista de Aeroportos
/// </summary>
/// <returns></returns>
      public List<Aeroportos> GetAeroportos()
    {
           List<Aeroportos> xList = new List<Aeroportos>();
            Aeroportos Aeroporto = new Aeroportos();
            Aeroporto.CODIGO = "SBGL";
            Aeroporto.NOME = "GALEAO";

            xList.Add(Aeroporto);

          return xList;
     }
}