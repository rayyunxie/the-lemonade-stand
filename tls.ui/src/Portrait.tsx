import './Portrait.css';

type Props = {
  imgSrc: string;
  imgAlt: string;
  primaryText: string;
  secondaryText: string;
};

export default function Portrait(props: Props) {
  return (
    <div className='Portrait'>
      <img src={props.imgSrc} alt={props.imgAlt} />
      <span>{props.primaryText}</span>
      <span>{props.secondaryText}</span>
    </div>
  );
}
