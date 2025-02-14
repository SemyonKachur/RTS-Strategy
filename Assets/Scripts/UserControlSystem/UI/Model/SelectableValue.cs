﻿using System;
using Abstractions;
using UnityEngine;

namespace UserControlSystem
{
    using Utils;

    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
    public class SelectableValue : StatefulScriptableObjectValueBase<ISelectable>
    {
    }
}