export const childRoutes = [
  {
    path: 'dashboard',
    loadChildren: () =>
      import('./dashboard/dashboard.module').then(m => m.DashboardModule),
    data: { icon: 'dashboard', text: 'Dashboard' }
  },
   
  {
    path: 'charts',
    loadChildren: () =>
      import('./charts/charts.module').then(m => m.ChartsModule),
    data: { icon: 'bar_chart', text: 'Charts' }
  },
  // {
  //   path: 'ProductList',
    
  //   loadChildren: () =>
  //     import('../products/products.module').then(m => m.ProductsModule),
  //   data: { icon: 'product', text: 'Product List' }
  // },

  {
    path: 'tables',
    loadChildren: () =>
      import('./tables/tables.module').then(m => m.TablesModule),
    data: { icon: 'table_chart', text: 'Patients' }
  },
  {
    path: 'test',
   // loadChildren: './users/users.module#UsersModule',
   loadChildren: () =>
   import('./test/test.module').then(m => m.TestModule),
    data: { icon: 'table_chart', text: 'Patients' }

   }
   ,
  {
    path: 'test',
   // loadChildren: './users/users.module#UsersModule',
   loadChildren: () =>
   import('../admin/subscriptions/subscriptions.module').then(m => m.SubscriptionsModule),
    data: { icon: 'table_chart', text: 'Patients' }

   }
    ,
    {
     path: 'subscriptions',
    // //  // loadChildren: './users/users.module#UsersModule',
    loadChildren: () =>
   import('./subscriptions/subscriptions.module').then(m => m.SubscriptionsModule),
     data: { icon: 'table_chart', text: 'subscriptions' }
    
   }
   

  
  // {
  //   path: 'forms',
  //   loadChildren: () => import('./forms/forms.module').then(m => m.FormsModule),
  //   data: { icon: 'assignment', text: 'Forms' }
  // },
  // {
  //   path: 'mat-grid',
  //   loadChildren: () =>
  //     import('./mat-grid/mat-grid.module').then(m => m.MatGridModule),
  //   data: { icon: 'grid_on', text: 'Flex Grid' }
  // },
  // {
  //   path: 'mat-components',
  //   loadChildren: () =>
  //     import('./mat-components/mat-components.module').then(
  //       m => m.MatComponentsModule
  //     ),
  //   data: { icon: 'code', text: 'Material Components' }
  // },
  // {
  //   path: 'animations',
  //   loadChildren: () =>
  //     import('./animations/animations.module').then(m => m.AnimationsModule),
  //   data: { icon: 'perm_media', text: 'Animations' }
  // },
  // {
  //   path: 'google-maps',
  //   loadChildren: () =>
  //     import('./google-map-demo/google-map-demo.module').then(
  //       m => m.GoogleMapDemoModule
  //     ),
  //   data: { icon: 'place', text: 'Google Maps' }
  // }
 

];
