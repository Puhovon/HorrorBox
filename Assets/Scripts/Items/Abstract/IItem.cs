using UnityEngine;

namespace Items.Abstract
{
    public interface IItem
    {
        Transform Transform { get; }
        void Take();
        void Drop();
    }
}