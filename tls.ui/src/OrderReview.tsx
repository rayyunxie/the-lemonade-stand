import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import DialogContentText from '@mui/material/DialogContentText';
import LinearProgress from '@mui/material/LinearProgress';
import {
  calculateTotalCostFromMap,
  compareProduct,
  Order,
  ProductView,
} from './types';
import { useState } from 'react';
import './OrderReview.css';

type Props = {
  products: Map<string, ProductView>;
  isOpen: boolean;
  isPlacingOrder: boolean;
  isError: boolean;
  setIsOpen: (isOpen: boolean) => void;
  onPlaceOrder: (newOrder: Order) => void;
};

export default function OrderReview({
  products,
  isOpen,
  isPlacingOrder,
  isError,
  setIsOpen,
  onPlaceOrder,
}: Props) {
  const handleClose = () => {
    if (!isPlacingOrder) {
      setIsOpen(false);
    }
  };
  const [name, setName] = useState('');
  const [contact, setContact] = useState('');

  const handlePlaceOrder = () => {
    const selectedProducts = Array.from(products.values()).filter(
      (product) => product.quantity > 0
    );

    const newOrder: Order = {
      products: selectedProducts.map((product) => {
        return {
          productId: product.id,
          quantity: product.quantity,
          unitPrice: product.price,
        };
      }),
      name,
      contact,
    };

    onPlaceOrder(newOrder);
  };

  return (
    <Dialog
      open={isOpen}
      onClose={handleClose}
      PaperProps={{
        style: {
          borderRadius: 0,
          backgroundColor: '#fafafa',
          minWidth: '180px',
        },
      }}
    >
      <DialogTitle>Order Review</DialogTitle>
      <DialogContent>
        <div className='OrderReview-table-wrapper'>
          <table className='OrderReview-table'>
            <tbody>
              {Array.from(products.values())
                .sort(compareProduct)
                .map(
                  (product) =>
                    product.quantity > 0 && (
                      <tr key={product.id}>
                        <td className='OrderReview-full-name'>{`${product.size.name} ${product.name}`}</td>
                        <td className='OrderReview-price'>
                          {product.price.toFixed(2)}
                        </td>
                        <td className='OrderReview-quantity'>{`x ${product.quantity}`}</td>
                        <td className='OrderReview-total'>
                          {(product.price * product.quantity).toFixed(2)}
                        </td>
                      </tr>
                    )
                )}
              <tr key='grand-total'>
                <td>Total</td>
                <td></td>
                <td className='OrderReview-grand-total'>{`$ ${calculateTotalCostFromMap(
                  products
                ).toFixed(2)}`}</td>
                <td></td>
              </tr>
            </tbody>
          </table>
        </div>
        <TextField
          autoFocus
          margin='dense'
          id='name'
          label='Name'
          type='text'
          value={name}
          fullWidth
          variant='standard'
          required
          disabled={isPlacingOrder}
          inputProps={{ maxLength: 60 }}
          onChange={(event) => setName(event.target.value)}
        />
        <TextField
          margin='dense'
          id='phoneOrEmail'
          label='Phone Number or Email'
          type='text'
          value={contact}
          fullWidth
          variant='standard'
          required
          disabled={isPlacingOrder}
          inputProps={{ maxLength: 256 }}
          onChange={(event) => setContact(event.target.value)}
        />

        {isError && (
          <DialogContentText textAlign='center' marginTop='20px'>
            Something went wrong there. <br />
            Try refreshing the page, or try again later.
          </DialogContentText>
        )}
      </DialogContent>
      <DialogActions sx={{ justifyContent: 'center' }}>
        <Button
          sx={{ textTransform: 'capitalize' }}
          onClick={handlePlaceOrder}
          disabled={
            name.trim().length === 0 ||
            contact.trim().length === 0 ||
            isPlacingOrder
          }
        >
          Place Order
        </Button>
      </DialogActions>
      <div className='OrderReview-loading'>
        {isPlacingOrder && <LinearProgress color='secondary' />}
      </div>
    </Dialog>
  );
}
