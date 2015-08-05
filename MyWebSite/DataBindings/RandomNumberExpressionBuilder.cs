﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;

using System.CodeDom;
using System.ComponentModel;
using System.Web.UI;

namespace MyWebSite.DataBindings
{
  /// <summary>
  /// Random Number expression builder - to build expression binding with CodeDom
  /// </summary>
  public class RandomNumberExpressionBuilder : ExpressionBuilder
  {
    public static string GetRandomNumber(int lowerLimit, int upperLimit)
    {
      Random rand = new Random();
      var randValue = rand.Next(lowerLimit, upperLimit);
      return randValue.ToString();
    }

    public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
    {
      if (!entry.Expression.Contains(","))
      {
        throw new ArgumentException("Must include two numbers separated by a comma.");
      }
      else
      {
        // get two numbers
        string[] numbers = entry.Expression.Split(',');
        if (numbers.Length != 2)
        {
          throw new ArgumentException("Only include two numbers");
        }
        else
        {
          int lowerLimit, upperLimit;
          if (Int32.TryParse(numbers[0], out lowerLimit) && Int32.TryParse(numbers[1], out upperLimit))
          {
            CodeTypeReferenceExpression typeRef = new CodeTypeReferenceExpression(this.GetType());
            CodeExpression[] methodParameters = new CodeExpression[2];
            methodParameters[0] = new CodePrimitiveExpression(lowerLimit);
            methodParameters[1] = new CodePrimitiveExpression(upperLimit);


            return new CodeMethodInvokeExpression(typeRef, "GetRandomNumber", methodParameters);
          }
          else
          {
            throw new ArgumentException("Use valid Integers");
          }
        }
      }
    }

  }
}