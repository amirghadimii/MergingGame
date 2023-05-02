using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMoneyCompany 
{
    //10 is a magic number. why 10!?!? create a const variable
    public  int Money;
  public  void MoneyUp()
  {
      Money += 10;
  }
  public  void MoneyDown()
  {
      Money -= 10;
  }
}
