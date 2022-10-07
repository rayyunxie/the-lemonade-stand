import './OrderNow.css';

type Props = {
  total: number;
  onOrderNow: () => void;
};

export default function OrderNow(props: Props) {
  const total = props.total;

  return (
    <div className='OrderNow'>
      <div>
        Total<span>{`$ ${total.toFixed(2)}`}</span>
      </div>
      <button type='button' onClick={props.onOrderNow} disabled={total < 0.01}>
        Order Now
      </button>
    </div>
  );
}
