import React from 'react';
import ComponentCreator from '@docusaurus/ComponentCreator';

export default [
  {
    path: '/your-project-name/__docusaurus/debug',
    component: ComponentCreator('/your-project-name/__docusaurus/debug', 'fb4'),
    exact: true
  },
  {
    path: '/your-project-name/__docusaurus/debug/config',
    component: ComponentCreator('/your-project-name/__docusaurus/debug/config', '007'),
    exact: true
  },
  {
    path: '/your-project-name/__docusaurus/debug/content',
    component: ComponentCreator('/your-project-name/__docusaurus/debug/content', '193'),
    exact: true
  },
  {
    path: '/your-project-name/__docusaurus/debug/globalData',
    component: ComponentCreator('/your-project-name/__docusaurus/debug/globalData', 'd52'),
    exact: true
  },
  {
    path: '/your-project-name/__docusaurus/debug/metadata',
    component: ComponentCreator('/your-project-name/__docusaurus/debug/metadata', '6ca'),
    exact: true
  },
  {
    path: '/your-project-name/__docusaurus/debug/registry',
    component: ComponentCreator('/your-project-name/__docusaurus/debug/registry', '13f'),
    exact: true
  },
  {
    path: '/your-project-name/__docusaurus/debug/routes',
    component: ComponentCreator('/your-project-name/__docusaurus/debug/routes', '7f8'),
    exact: true
  },
  {
    path: '/your-project-name/api',
    component: ComponentCreator('/your-project-name/api', 'c96'),
    exact: true
  },
  {
    path: '/your-project-name/markdown-page',
    component: ComponentCreator('/your-project-name/markdown-page', '366'),
    exact: true
  },
  {
    path: '/your-project-name/docs',
    component: ComponentCreator('/your-project-name/docs', '2a8'),
    routes: [
      {
        path: '/your-project-name/docs',
        component: ComponentCreator('/your-project-name/docs', '174'),
        routes: [
          {
            path: '/your-project-name/docs',
            component: ComponentCreator('/your-project-name/docs', '92c'),
            routes: [
              {
                path: '/your-project-name/docs/api-specification/calculator-model-generated',
                component: ComponentCreator('/your-project-name/docs/api-specification/calculator-model-generated', '116'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/api-specification/design-api-intro',
                component: ComponentCreator('/your-project-name/docs/api-specification/design-api-intro', '58c'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/api-specification/openapi-spec',
                component: ComponentCreator('/your-project-name/docs/api-specification/openapi-spec', 'ffb'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/category/api-specification',
                component: ComponentCreator('/your-project-name/docs/category/api-specification', 'cc9'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/category/requirements-specification',
                component: ComponentCreator('/your-project-name/docs/category/requirements-specification', '581'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/category/system-architecture',
                component: ComponentCreator('/your-project-name/docs/category/system-architecture', '8f8'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/category/test-procedures',
                component: ComponentCreator('/your-project-name/docs/category/test-procedures', 'e43'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/intro',
                component: ComponentCreator('/your-project-name/docs/intro', 'dcf'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/requirements/Features-and-Requirements',
                component: ComponentCreator('/your-project-name/docs/requirements/Features-and-Requirements', 'e7c'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/requirements/General-Requirements',
                component: ComponentCreator('/your-project-name/docs/requirements/General-Requirements', 'e5b'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/requirements/System-Block-Diagram',
                component: ComponentCreator('/your-project-name/docs/requirements/System-Block-Diagram', '18f'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/requirements/System-Overview',
                component: ComponentCreator('/your-project-name/docs/requirements/System-Overview', '505'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/requirements/Use-Case-Descriptions',
                component: ComponentCreator('/your-project-name/docs/requirements/Use-Case-Descriptions', 'd30'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/system-architecture/Algorithms',
                component: ComponentCreator('/your-project-name/docs/system-architecture/Algorithms', '847'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/system-architecture/Architecture',
                component: ComponentCreator('/your-project-name/docs/system-architecture/Architecture', 'c10'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/system-architecture/Development-Environment',
                component: ComponentCreator('/your-project-name/docs/system-architecture/Development-Environment', '810'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/system-architecture/Sequence-Diagrams',
                component: ComponentCreator('/your-project-name/docs/system-architecture/Sequence-Diagrams', 'cf4'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/system-architecture/Version-Control',
                component: ComponentCreator('/your-project-name/docs/system-architecture/Version-Control', '752'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/testing/acceptence-testing',
                component: ComponentCreator('/your-project-name/docs/testing/acceptence-testing', 'e75'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/testing/integration-testing',
                component: ComponentCreator('/your-project-name/docs/testing/integration-testing', '30f'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/docs/testing/unit-testing',
                component: ComponentCreator('/your-project-name/docs/testing/unit-testing', '05d'),
                exact: true,
                sidebar: "docsSidebar"
              }
            ]
          }
        ]
      }
    ]
  },
  {
    path: '/your-project-name/tutorial',
    component: ComponentCreator('/your-project-name/tutorial', 'feb'),
    routes: [
      {
        path: '/your-project-name/tutorial',
        component: ComponentCreator('/your-project-name/tutorial', 'b75'),
        routes: [
          {
            path: '/your-project-name/tutorial',
            component: ComponentCreator('/your-project-name/tutorial', '6e9'),
            routes: [
              {
                path: '/your-project-name/tutorial/category/custom-components',
                component: ComponentCreator('/your-project-name/tutorial/category/custom-components', '9e3'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/tutorial/category/tutorial---basics',
                component: ComponentCreator('/your-project-name/tutorial/category/tutorial---basics', 'e65'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/tutorial/category/tutorial---extras',
                component: ComponentCreator('/your-project-name/tutorial/category/tutorial---extras', '75f'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/tutorial/custom-components/figure',
                component: ComponentCreator('/your-project-name/tutorial/custom-components/figure', '615'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/tutorial/intro',
                component: ComponentCreator('/your-project-name/tutorial/intro', '1fd'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/tutorial/tutorial-basics/congratulations',
                component: ComponentCreator('/your-project-name/tutorial/tutorial-basics/congratulations', 'cfd'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/tutorial/tutorial-basics/create-a-document',
                component: ComponentCreator('/your-project-name/tutorial/tutorial-basics/create-a-document', 'afc'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/tutorial/tutorial-basics/create-a-page',
                component: ComponentCreator('/your-project-name/tutorial/tutorial-basics/create-a-page', 'f68'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/tutorial/tutorial-basics/deploy-your-site',
                component: ComponentCreator('/your-project-name/tutorial/tutorial-basics/deploy-your-site', '616'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/tutorial/tutorial-basics/markdown-features',
                component: ComponentCreator('/your-project-name/tutorial/tutorial-basics/markdown-features', '477'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/tutorial/tutorial-extras/manage-docs-versions',
                component: ComponentCreator('/your-project-name/tutorial/tutorial-extras/manage-docs-versions', 'ce8'),
                exact: true,
                sidebar: "docsSidebar"
              },
              {
                path: '/your-project-name/tutorial/tutorial-extras/translate-your-site',
                component: ComponentCreator('/your-project-name/tutorial/tutorial-extras/translate-your-site', '464'),
                exact: true,
                sidebar: "docsSidebar"
              }
            ]
          }
        ]
      }
    ]
  },
  {
    path: '/your-project-name/',
    component: ComponentCreator('/your-project-name/', 'bc9'),
    exact: true
  },
  {
    path: '*',
    component: ComponentCreator('*'),
  },
];
