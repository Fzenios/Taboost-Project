using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataForSaving
{
    public bool Sound;
    public bool Ads;
    public bool NSFW;
    public ExtraDataHere extradatahere;

    public DataForSaving(ExtraDataHere extradatahere)
    {
        Sound = extradatahere.Sound;
        Ads = extradatahere.Ads;
        NSFW = extradatahere.NSFW;
    }
}
