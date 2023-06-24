using System.Collections;
using System.Collections.Generic;
using Gallery.Source.Data;
using UnityEngine;

public class ConfigsProvider : IConfigsProvider
{
    public IGalleryConfig GalleryConfig { get; set; }
}
