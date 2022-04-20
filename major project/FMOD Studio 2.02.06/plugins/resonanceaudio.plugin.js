studio.plugins.registerPluginDescription('Resonance Audio Source', {
  companyName: 'Google',
  productName: 'Resonance Audio Source',

  deckUi: {
    deckWidgetType: studio.ui.deckWidgetType.Layout,
    layout: studio.ui.layoutType.HBoxLayout,
    spacing: 10,
    items: [
      {deckWidgetType: studio.ui.deckWidgetType.InputMeter},
      {
        deckWidgetType: studio.ui.deckWidgetType.Layout,
        layout: studio.ui.layoutType.VBoxLayout,
        spacing: 6,
        items: [
          {
            deckWidgetType: studio.ui.deckWidgetType.DistanceRolloffGraph,
            rolloffTypeBinding: 'Dist Rolloff',
            rolloffTypes: {
              // maps the values of "Dist Rolloff"
              0: studio.project.distanceRolloffType.Linear,
              1: studio.project.distanceRolloffType.Inverse,
              2: studio.project.distanceRolloffType.Custom,
              3: studio.project.distanceRolloffType.LinearSquared,
              4: studio.project.distanceRolloffType.InverseTapered,
            },
          },
          {
            deckWidgetType: studio.ui.deckWidgetType.Layout,
            layout: studio.ui.layoutType.HBoxLayout,
            spacing: 12,
            items: [
              {
                deckWidgetType: studio.ui.deckWidgetType.Dial,
                color: '#00d970',
                binding: 'Gain',
              },
              {
                deckWidgetType: studio.ui.deckWidgetType.Dial,
                binding: 'Spread',
              },
              {
                deckWidgetType: studio.ui.deckWidgetType.Dial,
                binding: 'Occlusion',
              },
              {
                deckWidgetType: studio.ui.deckWidgetType.Dial,
                binding: 'Near-Field Gain',
              },
            ],
          },
        ],
      },
      {
        deckWidgetType: studio.ui.deckWidgetType.Layout,
        layout: studio.ui.layoutType.VBoxLayout,
        spacing: 18,
        contentsMargins: {left: 6, top: 6, bottom: 6, right: 6},
        items: [
          {
            deckWidgetType: studio.ui.deckWidgetType.Layout,
            layout: studio.ui.layoutType.HBoxLayout,
            spacing: 15,
            items: [
              {
                deckWidgetType: studio.ui.deckWidgetType.Pixmap,
                filePath: __dirname + '/resonanceaudio_logo.png'
              },
            ],
          },
          {
            deckWidgetType: studio.ui.deckWidgetType.Layout,
            layout: studio.ui.layoutType.HBoxLayout,
            spacing: 7,
            items: [
              {
                deckWidgetType: studio.ui.deckWidgetType.Button,
                binding: 'Bypass Room',
              },
              {
                deckWidgetType: studio.ui.deckWidgetType.Button,
                binding: 'Near-Field FX',
              },
            ],
          },
        ],
      },
      {
        deckWidgetType: studio.ui.deckWidgetType.Layout,
        layout: studio.ui.layoutType.VBoxLayout,
        spacing: 12,
        items: [
          {
            deckWidgetType: studio.ui.deckWidgetType.PolarDirectivityGraph,
            directivityBinding: 'Directivity',
            sharpnessBinding: 'Dir Sharpness',
          },
          {
            deckWidgetType: studio.ui.deckWidgetType.Layout,
            layout: studio.ui.layoutType.HBoxLayout,
            spacing: 10,
            items: [
              {
                deckWidgetType: studio.ui.deckWidgetType.NumberBox,
                binding: 'Directivity',
              },
              {
                deckWidgetType: studio.ui.deckWidgetType.NumberBox,
                binding: 'Dir Sharpness',
              },
            ],
          }
        ],
      },
    ],
  },
});


studio.plugins.registerPluginDescription('Resonance Audio Soundfield', {
  companyName: 'Google',
  productName: 'Resonance Audio Soundfield',

  deckUi: {
    deckWidgetType: studio.ui.deckWidgetType.Layout,
    layout: studio.ui.layoutType.HBoxLayout,
    spacing: 10,
    items: [
      {deckWidgetType: studio.ui.deckWidgetType.InputMeter, numChannels: 4},
      {
        deckWidgetType: studio.ui.deckWidgetType.Layout,
        layout: studio.ui.layoutType.VBoxLayout,
        spacing: 7,
        contentsMargins: {left: 6, top: 6, bottom: 6, right: 6},
        items: [
          {
            deckWidgetType: studio.ui.deckWidgetType.Layout,
            layout: studio.ui.layoutType.HBoxLayout,
            spacing: 15,
            items: [
              {
                deckWidgetType: studio.ui.deckWidgetType.Pixmap,
                filePath: __dirname + '/resonanceaudio_logo.png'
              },
              {
                deckWidgetType: studio.ui.deckWidgetType.Dial,
                color: '#00d970',
                binding: 'Gain',
              },
            ],
          },
        ],
      },
    ],
  },
});


studio.plugins.registerPluginDescription('Resonance Audio Listener', {
  companyName: 'Google',
  productName: 'Resonance Audio Listener',

  deckUi: {
    deckWidgetType: studio.ui.deckWidgetType.Layout,
    layout: studio.ui.layoutType.HBoxLayout,
    spacing: 10,
    items: [
      {
        deckWidgetType: studio.ui.deckWidgetType.Layout,
        layout: studio.ui.layoutType.VBoxLayout,
        spacing: 7,
        contentsMargins: {left: 6, top: 6, bottom: 6, right: 6},
        items: [
          {
            deckWidgetType: studio.ui.deckWidgetType.Layout,
            layout: studio.ui.layoutType.HBoxLayout,
            spacing: 15,
            items: [
              {
                deckWidgetType: studio.ui.deckWidgetType.Pixmap,
                filePath: __dirname + '/resonanceaudio_logo.png'
              },
              {
                deckWidgetType: studio.ui.deckWidgetType.Dial,
                color: '#00d970',
                binding: 'Gain',
              },
            ],
          },
        ],
      },
      {deckWidgetType: studio.ui.deckWidgetType.OutputMeter},
    ],
  },
});
