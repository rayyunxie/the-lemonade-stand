import './OrderNow.css';

type Props = {
  total: number;
  onOrderNow: () => void;
};

export default function OrderNow({ total, onOrderNow }: Props) {
  return (
    <div className='OrderNow'>
      <div>
        Total<span>{`$ ${total.toFixed(2)}`}</span>
      </div>
      <button type='button' onClick={onOrderNow} disabled={total < 0.01}>
        Order Now
      </button>
    </div>
  );
}
