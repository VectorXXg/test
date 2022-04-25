using System;
using System.Collections.Generic;
using System.Text;
using Net.Component;

public class MyCommand : Command
{
    //变色
    public const byte ChangePlayerColor = 116;
    //
    public const byte RegisterObjectIndex = 117;
    //开火
    public const byte Fire = 118;

    //放置夹子
    public const byte Clip = 119;
}