import { useContext, useState } from 'react';
import Header from './Header';
import ProductTable from './ProductTable';
import {
  calculateTotalCostFromMap,
  NewOrder,
  Product,
  ProductView,
} from './types';
import OrderNow from './OrderNow';
import OrderReview from './OrderReview';
import './App.css';
import { useMutation } from 'react-query';
import { HttpContext } from './HttpContext';

const productData: Product[] = [
  {
    id: '4ec21273-714d-4926-8ef1-87f3087a9e4b',
    name: 'Lemonade',
    image: '',
    sizeName: 'Regular',
    sizeValue: 1,
    price: 1.0,
  },
  {
    id: '5051455a-8c3a-4a1d-9517-5bf99f91c2ac',
    name: 'Lemonade',
    image: '',
    sizeName: 'Large',
    sizeValue: 2,
    price: 1.5,
  },
  {
    id: '22a87a80-270e-4736-9409-ca93ed03ebb6',
    name: 'Pink Lemonade',
    image: '',
    sizeName: 'Regular',
    sizeValue: 1,
    price: 1.0,
  },
  {
    id: '2f0bd24d-ae45-40b0-a090-b0e914a05c04',
    name: 'Pink Lemonade',
    image: '',
    sizeName: 'Large',
    sizeValue: 2,
    price: 1.5,
  },
];

// TODO
//  confirm the final price with backend
//  show loading bar on query
//  set image file
//  limit name to 60
//  limit contact to 256

export default function App() {
  const httpClient = useContext(HttpContext).client;
  const createOrder = useMutation((newOrder: NewOrder) =>
    httpClient.post('/order', newOrder)
  );

  const [products, setProducts] = useState<Map<string, ProductView>>(
    productData.reduce(
      (prevValue: Map<string, ProductView>, currentValue) =>
        prevValue.set(currentValue.id, {
          id: currentValue.id,
          name: currentValue.name,
          image: currentValue.image,
          size: { name: currentValue.sizeName, value: currentValue.sizeValue },
          price: currentValue.price,
          quantity: 0,
        }),
      new Map()
    )
  );

  const [isReviewingOrder, setIsReviewingOrder] = useState(false);

  const handlePlaceOrder = (newOrder: NewOrder) => {
    createOrder.mutate(newOrder);
    // TODO
    // 1. send post request to api
    //    - send lemonade ids
    //    - send grand total
    // 2. show loading bar
    // 3. show toast message on completion
    // 4. close the popup
    // 5. clear the quantities
    // 6. reenable the ordernow button
  };

  // const widgets = useQuery('widgets', getWidgets);
  // if (widgets.isLoading) {
  //   return (
  //     <Box role='list' sx={{ display: 'grid', gridTemplateColumns: 'repeat(auto-fill, 250px)', gap: 2 }}>
  //       <Skeleton variant='rectangular' width={250} height={130} />
  //       <Skeleton variant='rectangular' width={250} height={130} />
  //       <Skeleton variant='rectangular' width={250} height={130} />
  //       <Skeleton variant='rectangular' width={250} height={130} />
  //     </Box>
  //   );
  // }
  // if (widgets.isError && widgets.error instanceof Error) {
  //   return <span>Error: {widgets.error.message}</span>;
  // }
  // if (!widgets.isSuccess) {
  //   return null;
  // }

  return (
    <div className='App'>
      <Header />
      <div className='Content'>
        <ProductTable
          products={products}
          handleChange={(newItems) => setProducts(newItems)}
        />
        <OrderNow
          total={calculateTotalCostFromMap(products)}
          onOrderNow={() => setIsReviewingOrder(true)}
        />
        <OrderReview
          products={products}
          isOpen={isReviewingOrder}
          setIsOpen={(isOpen) => setIsReviewingOrder(isOpen)}
          onPlaceOrder={handlePlaceOrder}
        />
      </div>
    </div>
  );
}
