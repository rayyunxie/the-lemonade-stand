import { useContext, useEffect, useState } from 'react';
import { useMutation, useQuery } from 'react-query';
import LinearProgress from '@mui/material/LinearProgress';
import Header from './Header';
import ProductTable from './ProductTable';
import {
  calculateTotalCostFromMap,
  Order,
  Product,
  ProductView,
} from './types';
import OrderNow from './OrderNow';
import OrderReview from './OrderReview';
import { HttpContext } from './HttpContext';
import { createOrder, getProducts } from './api';
import './App.css';
import Snackbar from '@mui/material/Snackbar';
import Slide, { SlideProps } from '@mui/material/Slide';
import { SnackbarCloseReason } from '@mui/base';
import Alert from '@mui/material/Alert';

function SlideTransition(props: SlideProps) {
  return <Slide {...props} direction='up' />;
}

export default function App() {
  const httpClient = useContext(HttpContext).client;

  const createOrderMutation = useMutation((order: Order) =>
    createOrder(httpClient, order)
  );

  const productsQuery = useQuery<Product[]>('products', () =>
    getProducts(httpClient)
  );

  const [products, setProducts] = useState<Map<string, ProductView>>(new Map());
  const [isReviewingOrder, setIsReviewingOrder] = useState(false);

  useEffect(() => {
    if (productsQuery.isSuccess) {
      setProducts((prev) => {
        const newProducts = productsQuery.data.reduce(
          (prevValue: Map<string, ProductView>, currentValue) =>
            prevValue.set(currentValue.id, {
              id: currentValue.id,
              name: currentValue.name,
              imageUrl: currentValue.imageUrl,
              size: {
                name: currentValue.sizeName,
                value: currentValue.sizeValue,
              },
              price: currentValue.price,
              quantity: prev.get(currentValue.id)?.quantity || 0,
            }),
          new Map()
        );
        return newProducts;
      });
    }
  }, [productsQuery.data, productsQuery.isSuccess]);

  useEffect(() => {
    // clear out quantity on successful orders
    if (createOrderMutation.isSuccess) {
      setProducts((prev) => {
        prev.forEach((product) => (product.quantity = 0));
        return new Map(prev);
      });
    }
  }, [createOrderMutation.isSuccess]);

  const handleOrderNow = () => {
    createOrderMutation.reset();
    setIsReviewingOrder(true);
  };

  const handlePlaceOrder = (newOrder: Order) => {
    createOrderMutation.mutate(newOrder);
  };

  const handleSnackbarClose = (reason?: SnackbarCloseReason) => {
    // disable clickaway on Snackbar
    if (reason !== 'clickaway') {
      createOrderMutation.reset();
      setIsReviewingOrder(false);
    }
  };

  const renderError = () => (
    <>
      <h2 className='Error'>Something went wrong</h2>
      <p>Try refreshing the page, or try again later.</p>
    </>
  );

  const totalCost = calculateTotalCostFromMap(products);

  return (
    <div className='App'>
      {productsQuery.isLoading && (
        <LinearProgress
          color='secondary'
          sx={{
            position: 'fixed',
            top: 0,
            width: '100%',
          }}
        />
      )}
      <Header />
      {productsQuery.isError && productsQuery.error instanceof Error ? (
        renderError()
      ) : (
        <div className='Content'>
          <ProductTable
            isLoading={productsQuery.isLoading}
            products={products}
            handleChange={(newItems) => setProducts(newItems)}
          />
          <OrderNow total={totalCost} onOrderNow={handleOrderNow} />
          <OrderReview
            isPlacingOrder={createOrderMutation.isLoading}
            isError={createOrderMutation.isError}
            products={products}
            isOpen={
              isReviewingOrder &&
              totalCost >= 0.01 &&
              !createOrderMutation.isSuccess
            }
            setIsOpen={(isOpen) => setIsReviewingOrder(isOpen)}
            onPlaceOrder={handlePlaceOrder}
          />
          <Snackbar
            open={createOrderMutation.isSuccess}
            onClose={(_, reason) => handleSnackbarClose(reason)}
            TransitionComponent={SlideTransition}
            anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }}
          >
            <Alert
              onClose={() => handleSnackbarClose()}
              severity='success'
              sx={{ width: '100%' }}
            >
              Order placed!
              <br />
              {`Order # ${createOrderMutation.data?.id}`}
            </Alert>
          </Snackbar>
        </div>
      )}
    </div>
  );
}
