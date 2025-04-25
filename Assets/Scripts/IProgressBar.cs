using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProgressBar 
{
    public event EventHandler<OnProgressBarEventArgs> OnProgressBar;
    public class OnProgressBarEventArgs : EventArgs
    {
        public float progress;
    }
}
