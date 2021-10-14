//import * as React from 'react';
//import { connect } from 'react-redux';
//import { RouteComponentProps } from 'react-router';
//import { ApplicationState } from '../store';
//import * as CounterStore from '../store/Counter';


//import { Row, Col } from 'mdbreact';
//import { NavLink } from 'react-router-dom';
//import PropTypes from 'prop-types';



//type CounterProps =
//    CounterStore.CounterState &
//    typeof CounterStore.actionCreators &
//    RouteComponentProps<{}>;

//class BloodWorkForm extends React.PureComponent<CounterProps> {
//    public render() {
//        return (
//            <React.Fragment>
//                <h1>Counter</h1>

//                <p>This is a simple example of a React component.</p>

//                <p aria-live="polite">Current count: <strong>{this.props.count}</strong></p>

//                <button type="button"
//                    className="btn btn-primary btn-lg"
//                    onClick={() => { this.props.increment(); }}>
//                    Increment
//                </button>
//            </React.Fragment>
//        );
//    }
//};

//export default connect(
//    (state: ApplicationState) => state.counter,
//    CounterStore.actionCreators
//)(BloodWorkForm);






//import TextInputElements from '../UI/FormElements/TextInputElements';
//import Aux from '../../hoc/Auxi/Auxi';
//import Spinner from '../../components/UI/Spinner/Spinner';

//const authForm = (props) => {
//    let form = <Spinner />;
//    if (!props.loading) {
//        form = (<TextInputElements
//            formElementsArray={props.formElementsArray}
//            showPassword={props.showPassword}
//            inputChanged={props.inputChanged}
//            formErrors={props.error && typeof props.error.message === 'object' ? props.error.message : null}
//        />);
//    }

//    let errorMessage = null;
//    if (props.error && typeof props.error.message === 'string') {
//        errorMessage = (
//            <p style={{ color: 'red' }}>{props.error.message}</p>
//        );
//    }

//    let forgotPass = <div />;
//    if (!props.isSignup) {
//        forgotPass = (
//            <Col md="6">
//                <p className="font-small white-text d-flex justify-content-start">Forgot your password?
//          <NavLink to="/" className="green-text ml-1 font-bold"> Reset password</NavLink>
//                </p>
//            </Col>
//        );
//    }

//    return (
//        <Aux>
//            <div className="text-center">
//                <h3 className="white-text mb-5 mt-4 font-bold">
//                    <strong>SIGN</strong>
//                    <a className="green-text font-bold">
//                        <strong> {props.isSignup ? 'UP' : 'IN'}</strong>
//                    </a>
//                </h3>
//            </div>
//            {errorMessage}
//            <form onSubmit={props.submit}>
//                {form}
//                <Row className="d-flex align-items-center mb-4">
//                    <Col md="12" className="text-center mb-3">
//                        {errorMessage}
//                        <button type="submit" className="btn btn-outline-white buttonsColor">
//                            {props.isSignup ? 'Register' : 'Sign in'}
//                            <i className="fas fa-sign-in-alt ml-2" />
//                        </button>
//                    </Col>
//                </Row>
//            </form>
//            <Row style={{ width: '80vw', maxWidth: '620px' }}>
//                {forgotPass}
//                <Col md="6">
//                    <p className="font-small white-text d-flex justify-content-end">
//                        {props.isSignup ? 'Have an account?' : 'Don\'t have an account?'}
//                        <NavLink
//                            to={props.isSignup ? '/signin' : '/register'}
//                            onClick={props.clearError}
//                            className="green-text ml-1 font-bold"
//                        >
//                            {props.isSignup ? 'Log in' : 'Register'}
//                        </NavLink>
//                    </p>
//                </Col>
//            </Row>
//        </Aux>
//    );
//};

//authForm.propTypes = {
//    isSignup: PropTypes.bool.isRequired,
//    loading: PropTypes.bool.isRequired,
//    formElementsArray: PropTypes.arrayOf(PropTypes.object).isRequired,
//    // eslint-disable-next-line
//    error: PropTypes.object,
//    showPassword: PropTypes.func.isRequired,
//    inputChanged: PropTypes.func.isRequired,
//    submit: PropTypes.func.isRequired,
//    clearError: PropTypes.func.isRequired,
//};

//authForm.defaultProps = {
//    error: null,
//};

//export default authForm;
